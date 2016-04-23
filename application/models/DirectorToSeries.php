<?php
/**
 * This file contains...TODO
 * Created by Soma Veszelovszki <soma.veszelovszki@gmail.com> on 2016-04-23.
 */

class DirectorToSeries extends Model {

    protected $_directorId;
    protected $_seriesId;

    function __construct($data = null)
    {
        // Call the Model constructor
        parent::__construct($data);
    }

    public function getDirectorId() {
        return $this->_directorId;
    }

    public function setDirectorId($directorId) {
        $this->_directorId = $directorId;
    }

    public function getSeriesId() {
        return $this->_seriesId;
    }

    public function setSeriesId($seriesId) {
        $this->_seriesId = $seriesId;
    }
}