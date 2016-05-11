<?php
/**
 * This file contains...TODO
 * Created by Soma Veszelovszki <soma.veszelovszki@gmail.com> on 2016-04-25.
 */

require "vendor/autoload.php";

use Model\AgeLimitTable;
use Model\GenreTable;
use Model\CountryTable;
use Model\SeriesTable;
use Model\ContributionTable;
use Model\PersonTable;
use Model\Series;
use Model\PersonToSeries;
use Model\PersonToSeriesTable;

if ( ! defined('BASEPATH')) exit('No direct script access allowed');


class SeriesController extends CI_Controller {

    public function indexAction($seriesList = null, $searched = false) {
        $this->listAction($seriesList, $searched);
    }

    public function listAction($seriesList = null, $searched = false)
    {
        if ($searched && !$seriesList) {
            $this->load->view('series_list', [
                'seriesList'    =>  null,
                'message'       =>  'Series not found.'
            ]);
            return;
        }

        $seriesList = $seriesList ? $seriesList : SeriesTable::getInstance()->getAll();

        $this->load->view('series_list', [
            'seriesList'    =>  $seriesList ? $seriesList : [],
        ]);
    }

    public function editAction($seriesId = null){
        if (!$seriesId) {
            $errorMessage = "Series id missing.";
            $this->load->view('error', ['errorMessage' => $errorMessage]);
            return;
        }

        $series = SeriesTable::getInstance()->getOne(['id' => $seriesId]);
        $countries = CountryTable::getInstance()->getAll();
        $ageLimits = AgeLimitTable::getInstance()->getAll();
        $genres = GenreTable::getInstance()->getAll();
        $contributions = ContributionTable::getInstance()->getAll();
        $persons = PersonTable::getInstance()->getAll();

        if (!$series) {
            $errorMessage = "Series of given id (" . $seriesId . ") not found in database.";
            $this->load->view('error', ['errorMessage' => $errorMessage]);
            return;
        }

        $this->load->view('series', [
            'series'    =>  $series,
            'countries' =>  $countries,
            'ageLimits' =>  $ageLimits,
            'genres'    =>  $genres,
            'contributions' =>  $contributions,
            'persons'   =>  $persons
        ]);
    }

    public function searchAction() {
        $searchText = $this->input->post('searchText');
        $seriesList = SeriesTable::getInstance()->getAll(['title' => $searchText]);

        if ($seriesList && count($seriesList) == 1) {
            $this->editAction($seriesList[0]->getId());
        } else {
            $this->listAction($seriesList, true);
        }
    }

    public function saveAction(){
        $seriesData['id'] = $this->input->post('id');
        $seriesData['title'] = $this->input->post('title');
        $seriesData['countryId'] = $this->input->post('country_id');
        $seriesData['genreId'] = $this->input->post('genre_id');
        $seriesData['ageLimitId'] = $this->input->post('age_limit_id');
        $seriesData['viewNumber'] = $this->input->post('view_number');
        $seriesData['isOnProgram'] = $this->input->post('is_on_program');
        $seriesData['showTime'] = $this->input->post('show_time');
        $seriesData['imdbId'] = $this->input->post('imdb_id');

        $contributions = $this->input->post('contributions');

        if (empty($seriesData['title'])) {
            $this->output->set_output(json_encode([
                'success' => false,
                'message'    => "Series cannot be saved, because title has not been given."
            ]));
            return;
        }

        $series = new Series($seriesData);

        try {
            SeriesTable::getInstance()->save($series);

            if ($series->getId()) {

                // gets contribution ids that are already in the database
                $contributionsInDB = [];
                foreach ($series->getPersonContributions() as $contributionInDB) {
                    $contributionsInDB[] = $contributionInDB->getId();
                }

                $savedContributionIds = [];

                if (!empty($contributions)) {

                    foreach ($contributions as $contributionData) {
                        if (!$contributionData['id']) {
                            $personToSeries = new PersonToSeries([
                                'seriesId' => $series->getId(),
                                'personId' => $contributionData['personId'],
                                'contributionId' => $contributionData['contributionId']
                            ]);

                            PersonToSeriesTable::getInstance()->save($personToSeries);
                        } else {
                            $savedContributionIds[] = $contributionData['id'];
                        }
                    }
                }

                $contributionIdsToDelete = array_diff($contributionsInDB, $savedContributionIds);

                foreach($contributionIdsToDelete as $contributionId) {
                    PersonToSeriesTable::getInstance()->delete(['id'=>$contributionId]);
                }
            }

        } catch (Exception $e) {
            $this->output->set_output(json_encode([
                'success' => false,
                'message'    => "Series cannot be saved due to a database error."
            ]));
            return;
        }

        $this->output->set_output(json_encode([
            'success' => true
        ]));    }
}