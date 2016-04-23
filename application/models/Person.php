<?php
/**
 * This file contains...TODO
 * Created by Soma Veszelovszki <soma.veszelovszki@gmail.com> on 2016-04-23.
 */

class Person extends Model {

    protected $_firstName;
    protected $_surname;
    protected $_birthDate;
    protected $_countryId;

    function __construct($data = null)
    {
        // Call the Model constructor
        parent::__construct($data);
    }

    public function getFirstName() {
        return $this->_firstName;
    }

    public function setFirstName($firstName) {
        $this->_firstName = $firstName;
    }

    public function getSurname() {
        return $this->_surname;
    }

    public function setSurname($surname) {
        $this->_surname = $surname;
    }

    public function getBirthDate() {
        return $this->_birthDate;
    }

    public function getBirthDateInSQLDateFormat() {
        return getSQLDateFromDateTime($this->_birthDate);
    }

    public function setBirthDate($birthDate) {
        $this->_birthDate = getDateTimeFromSQLDate($birthDate);
    }

    public function getCountryId() {
        return $this->_countryId;
    }

    public function setCountryId($countryId) {
        $this->_countryId = (int) $countryId;
    }
}