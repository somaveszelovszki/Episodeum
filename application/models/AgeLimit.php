<?php
/**
 * This file contains...TODO
 * Created by Soma Veszelovszki <soma.veszelovszki@gmail.com> on 2016-04-23.
 */

namespace Episodeum\Model;

class AgeLimit extends Model {

    protected $_age;

    function __construct($data = null)
    {
        // Call the Model constructor
        parent::__construct($data);
    }

    public function getAge() {
        return $this->_age;
    }

    public function setAge($age) {
        $this->_age = $age;
    }
}