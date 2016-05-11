<?php
/**
 * This file contains...TODO
 * Created by Soma Veszelovszki <soma.veszelovszki@gmail.com> on 2016-04-23.
 */

namespace Model;

class PersonTable extends TableModel {

    const TABLE_NAME = 'person';

    /**
     * Applies query filters (WHERE, LIMIT, ORDER BY)
     * @param array $filters
     * @param null $order
     * @param null $limit
     */
    protected function _applyFilters(array $filters = [], $order = self::ORDER_NONE, $limit = null) {
        /* Applies filters */
        if (isset($filters['name'])) {
            $this->db->like("CONCAT_WS(' ', main_table.first_name, main_table.surname)", $filters['name']);
        }

        parent::_applyFilters($filters, $order, $limit);
    }

    protected function _rowToModel($row){
        return new Person([
            'id'            =>  (int) $row->id,
            'firstName'     =>  $row->first_name,
            'surname'       =>  $row->surname,
            'genderId'      =>  $row->gender_id,
            'birthDate'     =>  $row->birth_date ? $row->birth_date : null,
            'countryId'     =>  $row->country_id ? $row->country_id : null,

        ]);
    }

    /**
     * @param Person $person
     * @return array
     */
    public function _modelToRow($person)
    {
        return [
            'id'            =>  $person->getId(),
            'first_name'    =>  $person->getFirstName(),
            'surname'       =>  $person->getSurname(),
            'gender_id'     =>  $person->getGenderId(),
            'birth_date'    =>  $person->getBirthDate(),
            'country_id'    =>  $person->getCountryId()
        ];
    }
}