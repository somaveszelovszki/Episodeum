<?php
/**
 * This file contains...TODO
 * Created by Soma Veszelovszki <soma.veszelovszki@gmail.com> on 2016-04-23.
 */

class ActorToSeries extends Model {

    protected $_actorId;
    protected $_seriesId;

    function __construct($data = null)
    {
        // Call the Model constructor
        parent::__construct($data);
    }

    public function getActorId() {
        return $this->_actorId;
    }

    public function setActorId($actorId) {
        $this->_actorId = $actorId;
    }

    public function getSeriesId() {
        return $this->_seriesId;
    }

    public function setSeriesId($seriesId) {
        $this->_seriesId = $seriesId;
    }
}