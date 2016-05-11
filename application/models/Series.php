<?php
/**
 * This file contains...TODO
 * Created by Soma Veszelovszki <soma.veszelovszki@gmail.com> on 2016-04-23.
 */

namespace Model;

class Series extends Model {

    protected $_imdbId;
    protected $_title;
    protected $_ageLimitId;
    protected $_genreId;
    protected $_isOnProgram;
    protected $_showTime;
    protected $_viewNumber;
    protected $_countryId;

    function __construct($data = null)
    {
        // Call the Model constructor
        parent::__construct($data);
    }

    public function getImdbId() {
        return $this->_imdbId;
    }

    public function setImdbId($imdbId) {
        $this->_imdbId = $imdbId;
    }

    public function getTitle() {
        return $this->_title;
    }

    public function setTitle($title) {
        $this->_title = $title;
    }

    public function getAgeLimitId() {
        return $this->_ageLimitId;
    }

    public function getAgeLimit(){
        $ageLimitId = $this->getAgeLimitId();
        return $ageLimitId ? AgeLimitTable::getInstance()->getOne(['id' => $ageLimitId]) : null;
    }

    public function setAgeLimitId($ageLimitId) {
        $this->_ageLimitId = (int) $ageLimitId;
    }

    public function getGenreId() {
        return $this->_genreId;
    }

    public function getGenre(){
        $genreId = $this->getGenreId();
        return $genreId ? GenreTable::getInstance()->getOne(['id' => $genreId]) : null;
    }

    public function setGenreId($genreId) {
        $this->_genreId = (int)$genreId;
    }

    public function getIsOnProgram() {
        return $this->_isOnProgram;
    }

    public function setIsOnProgram($isOnProgram) {
        $this->_isOnProgram = (bool)$isOnProgram;
    }

    public function getShowTime() {
        return $this->_showTime;
    }

    public function getShowTimeInSQLDateTimeFormat() {
        return getSQLDateTimeFromDateTime($this->_showTime);
    }

    public function getShowTimeAsTVShowTime() {
        return $this->_showTime ? $this->_showTime->format("l, H:i") : null;
    }

    public function getShowTimeDayId(){
        return $this->_showTime ? $this->_showTime->format('w') : null;
    }

    public function getShowTimeInTimeFormat(){
        return $this->_showTime ? $this->_showTime->format('H:i') : null;
    }

    public function setShowTime($showTime) {
        $this->_showTime = getDateTimeFromSQLDateTime($showTime);
    }

    public function getViewNumber() {
        return $this->_viewNumber;
    }

    public function setViewNumber($viewNumber) {
        $this->_viewNumber = (int) $viewNumber;
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

    public function getPersonContributions() {
        return PersonToSeriesTable::getInstance()->getAll(['series_id' => $this->getId()]);
    }

    public function getPersonContributionsWithPersonData(){
        $contributionList = $this->getPersonContributions();
        if (!$contributionList) {
            return null;
        }

        $list = [];
        foreach($contributionList as $con) {
            $person = PersonTable::getInstance()->getOne(['id' => $con->getPersonId()]);
            $contribution = ContributionTable::getInstance()->getOne(['id' => $con->getContributionId()]);

            $list[] = [
                'contribution'  =>  $contribution,
                'person'        =>  $person
            ];
        }

        return sortArrayOfArraysByKey($list, 'contribution', SORT_DESC);
    }
}