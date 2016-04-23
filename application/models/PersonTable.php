<?php
/**
 * This file contains...TODO
 * Created by Soma Veszelovszki <soma.veszelovszki@gmail.com> on 2016-04-23.
 */

class PersonTable extends TableModel {

    protected function _rowToModel($row){
        return new Person([
            'id'            =>  (int) $row->id,
            'firstName'     =>  $row->first_name,
            'surname'       =>  $row->surname,
            'birthDate'     =>  $row->birth_date ? $row->birth_date : null,
            'countryId'     =>  $row->country_id ? $row->country_id : null,

        ]);
    }

    /**
     * @param Person $person
     * @return array
     */
    protected function _modelToRow($person)
    {
        return [
            'id'            =>  $person->getId(),
            'first_name'    =>  $person->getFirstName(),
            'surname'       =>  $person->getSurname(),
            'birth_date'    =>  $person->getBirthDate(),
            'country_id'    =>  $person->getCountryId()
        ];
    }
}