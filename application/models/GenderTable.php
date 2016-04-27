<?php
/**
 * This file contains...TODO
 * Created by Soma Veszelovszki <soma.veszelovszki@gmail.com> on 2016-04-25.
 */

namespace Model;

class GenderTable extends TableModel {

    const TABLE_NAME = 'gender';

    protected function _rowToModel($row){
        return new Gender([
            'id'    =>  (int) $row->id,
            'name'  =>  $row->name
        ]);
    }

    /**
     * @param Gender $gender
     * @return array
     */
    protected function _modelToRow($gender)
    {
        return [
            'id' => $gender->getId(),
            'name' => $gender->getName(),
        ];
    }
}