<?php
/**
 * This file contains...TODO
 * Created by Soma Veszelovszki <soma.veszelovszki@gmail.com> on 2016-04-23.
 */

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

    public function setAgeLimitId($ageLimitId) {
        $this->_ageLimitId = (int) $ageLimitId;
    }

    public function getGenreId() {
    return $this->_genreId;
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

    public function setCountryId($countryId) {
        $this->_countryId = (int) $countryId;
    }
}