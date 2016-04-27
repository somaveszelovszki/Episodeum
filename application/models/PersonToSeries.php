<?php
/**
 * This file contains...TODO
 * Created by Soma Veszelovszki <soma.veszelovszki@gmail.com> on 2016-04-26.
 */

namespace Model;

class PersonToSeries extends Model {

    protected $_personId;
    protected $_seriesId;
    protected $_contributionId;

    function __construct($data = null)
    {
        // Call the Model constructor
        parent::__construct($data);
    }

    public function getPersonId() {
        return $this->_personId;
    }

    public function setPersonId($personId) {
        $this->_personId = $personId;
    }

    public function getSeriesId() {
        return $this->_seriesId;
    }

    public function setSeriesId($seriesId) {
        $this->_seriesId = $seriesId;
    }

    public function getContributionId() {
        return $this->_contributionId;
    }

    public function setContributionId($contributionId) {
        $this->_contributionId = $contributionId;
    }
}