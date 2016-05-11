<?php
/**
 * This file contains...TODO
 * Created by Soma Veszelovszki <soma.veszelovszki@gmail.com> on 2016-05-05.
 */

require "vendor/autoload.php";


if ( ! defined('BASEPATH')) exit('No direct script access allowed');

class ErrorController extends CI_Controller {

    public function indexAction($errorMessage = null)
    {
        $this->load->view('error', [
            'errorMessage'  =>  $errorMessage
        ]);
    }
}