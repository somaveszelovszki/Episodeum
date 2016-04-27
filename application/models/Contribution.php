<?php
/**
 * This file contains...TODO
 * Created by Soma Veszelovszki <soma.veszelovszki@gmail.com> on 2016-04-26.
 */

namespace Model;


class Contribution extends Model {

    protected $_name;

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
}