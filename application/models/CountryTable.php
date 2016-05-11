<?php
/**
 * This file contains...TODO
 * Created by Soma Veszelovszki <soma.veszelovszki@gmail.com> on 2016-04-23.
 */

namespace Model;

class CountryTable extends TableModel {

    const TABLE_NAME = 'country';

    protected function _rowToModel($row){
        return new Country([
            'id'            =>  (int) $row->id,
            'name'          =>  $row->name,
            'nationality'   =>  $row->nationality
        ]);
    }

    /**
     * @param Country $country
     * @return array
     */
    public function _modelToRow($country)
    {
        return [
            'id'            =>  $country->getId(),
            'name'          =>  $country->getName(),
            'nationality'   =>  $country->getNationality()
        ];
    }
}