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

    public function dataAction($seriesId = null){
        if (!$seriesId) {
            $errorMessage = "Series id missing.";
            $this->load->view('error', ['errorMessage' => $errorMessage]);
            return;
        }

        $series = SeriesTable::getInstance()->getOne(['id' => $seriesId]);

        if (!$series) {
            $errorMessage = "Series of given id (" . $seriesId . ") not found in database.";
            $this->load->view('error', ['errorMessage' => $errorMessage]);
            return;
        }

        $this->load->view('series', [
            'series'    =>  $series,
        ]);
    }

    public function searchAction() {
        $searchText = $this->input->post('searchText');
        $seriesList = \Model\SeriesTable::getInstance()->getAll(['title' => $searchText]);

        $this->listAction($seriesList, true);
    }
}