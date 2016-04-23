<?php
/**
 * This file contains...TODO
 * Created by Soma Veszelovszki <soma.veszelovszki@gmail.com> on 2016-04-22.
 */

namespace Episodeum\Model;

class Model extends CI_Model
{
    /**
     * @var int|null Unique ID of the object in the DB. Null means the object is not saved in the DB.
     */
    protected $_id;

    /**
     * Initializes model from associative array
     * @param array $data initial data
     */
    public function __construct($data = []) {
        if (is_array($data) && !empty($data)) {
            foreach ($data as $key => $value) {
                try {
                    $this->{'set' . ucfirst($key)}($value);
                } catch (Exception $e) {
                    // do nothing
                }
            }
        }
    }

    /**
     * @return int|null id of the object
     */
    public function getId() {
        return $this->_id;
    }

    /**
     * @param $id int|null id to be set
     */
    public function setId($id) {
        $this->_id = $id ? $id : null;
    }
}