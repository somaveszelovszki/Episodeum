<?php
/**
 * This file contains...TODO
 * Created by Soma Veszelovszki <soma.veszelovszki@gmail.com> on 2016-04-22.
 */

require "vendor/autoload.php";


if ( ! defined('BASEPATH')) exit('No direct script access allowed');

class SearchController extends CI_Controller {

    public function indexAction()
    {
        $this->load->view('search');
    }
}