<?php
/**
 * This file contains...TODO
 * Created by Soma Veszelovszki <soma.veszelovszki@gmail.com> on 2016-04-26.
 */

require "vendor/autoload.php";

use Model\AgeLimitTable;
use Model\GenreTable;
use Model\CountryTable;
use Model\SeriesTable;
use Model\PersonTable;

if ( ! defined('BASEPATH')) exit('No direct script access allowed');


class PersonController extends CI_Controller {

    public function indexAction($personList = null, $searched = false) {
        $this->listAction($personList, $searched);
    }

    public function listAction($personList = null, $searched = false) {
        if ($searched && !$personList) {
            $this->load->view('person_list', [
                'personList'    =>  null,
                'message'       =>  'Person not found.'
            ]);
            return;
        }

        $personList = $personList ? $personList : PersonTable::getInstance()->getAll();

        $this->load->view('person_list', [
            'personList'    =>  $personList ? $personList : [],
        ]);
    }

    public function editAction($personId = null)
    {
        if (!$personId) {
            $errorMessage = "Actor id missing.";
            $this->load->view('error', ['errorMessage' => $errorMessage]);
            return;
        }

        $person = PersonTable::getInstance()->getOne(['id' => $personId]);

        if (!$person) {
            $errorMessage = "Actor of given id (" . $personId . ") not found in database.";
            $this->load->view('error', ['errorMessage' => $errorMessage]);
            return;
        }

        $this->load->view('person', [
            'person'    =>  $person,
        ]);
    }

    public function searchAction() {
        $searchText = $this->input->post('searchText');
        $personList = \Model\PersonTable::getInstance()->getAll(['name' => $searchText]);

        if ($personList && count($personList) == 1) {
            $this->editAction($personList[0]->getId());
        } else {
            $this->listAction($personList, true);
        }
    }
}