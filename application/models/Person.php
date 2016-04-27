<?php
/**
 * This file contains...TODO
 * Created by Soma Veszelovszki <soma.veszelovszki@gmail.com> on 2016-04-23.
 */

namespace Model;

class Person extends Model {

    protected $_firstName;
    protected $_surname;
    protected $_genderId;
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

    public function getName() {
        return $this->getFirstName() . ' ' . $this->getSurname();
    }

    public function setSurname($surname) {
        $this->_surname = $surname;
    }

    public function getGenderId() {
        return $this->_genderId;
    }

    public function getGender(){
        $genderId = $this->getGenderId();
        return $genderId ? GenderTable::getInstance()->getOne(['id' => $genderId]) : null;
    }

    public function setGenderId($genderId) {
        $this->_genderId = $genderId;
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

    public function getCountry(){
        $countryId = $this->getCountryId();
        return $countryId ? CountryTable::getInstance()->getOne(['id' => $countryId]) : null;
    }

    public function setCountryId($countryId) {
        $this->_countryId = (int) $countryId;
    }

    public function getSeriesContributions() {
        return PersonToSeriesTable::getInstance()->getAll(['person_id' => $this->getId()]);
    }

    public function getSeriesContributionsAsString(){
        $contributionList = $this->getSeriesContributions();
        if (!$contributionList) {
            return 'This person has not contributed to any series.';
        }

        $text = '';
        foreach($contributionList as $con) {
            $series = SeriesTable::getInstance()->getOne(['id' => $con->getSeriesId()]);
            $contribution = ContributionTable::getInstance()->getOne(['id' => $con->getContributionId()]);

            $text .= $series->getTitle() . ': ' . $contribution->getName() . '<br />';
        }
        return $text;
    }

    public function getSeriesContributionsWithSeriesData(){
        $contributionList = $this->getSeriesContributions();
        if (!$contributionList) {
            return null;
        }

        $list = [];
        foreach($contributionList as $con) {
            $series = SeriesTable::getInstance()->getOne(['id' => $con->getSeriesId()]);
            $contribution = ContributionTable::getInstance()->getOne(['id' => $con->getContributionId()]);

            $list[] = [
                'contribution'  =>  $contribution,
                'series'        =>  $series
            ];
        }

        return sortArrayOfArraysByKey($list, 'contribution', SORT_DESC);
    }
}