<?php
/**
 * This file contains...TODO
 * Created by Soma Veszelovszki <soma.veszelovszki@gmail.com> on 2016-04-22.
 */

if ( ! defined('BASEPATH')) exit('No direct script access allowed');

class MainController extends CI_Controller {

    public function index()
    {
        $this->load->view('index');
    }
}