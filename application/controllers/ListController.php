<?php
/**
 * This file contains...TODO
 * Created by Soma Veszelovszki <soma.veszelovszki@gmail.com> on 2016-04-22.
 */

use Episodeum\Model\AgeLimitTable;

if ( ! defined('BASEPATH')) exit('No direct script access allowed');


class ListController extends CI_Controller {

    public function index()
    {
        //$this->load->model('AgeLimitTable');
        $seriesList = AgeLimitTable::getInstance()->getAll();

        $this->load->view('list', $seriesList);
    }
}