<?php
/**
 * This file contains...TODO
 * Created by Soma Veszelovszki <soma.veszelovszki@gmail.com> on 2016-04-23.
 */

class Country extends Model {

    protected $_name;
    protected $_nationality;

    function __construct($data = null)
    {
        // Call the Model constructor
        parent::__construct($data);
    }

    public function getName() {
        return $this->_name;
    }

    public function setName($name) {
        $this->_name = $name;
    }

    public function getNationality() {
        return $this->_nationality;
    }

    public function setNationality($nationality) {
        $this->_nationality = $nationality;
    }
}