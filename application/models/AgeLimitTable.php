<?php
/**
 * This file contains...TODO
 * Created by Soma Veszelovszki <soma.veszelovszki@gmail.com> on 2016-04-23.
 */

namespace Model;

class AgeLimitTable extends TableModel {

    const TABLE_NAME = 'age_limit';

    protected function _rowToModel($row){
        return new AgeLimit([
            'id'    =>  (int) $row->id,
            'age'   =>  (int) $row->age
        ]);
    }

    /**
     * @param AgeLimit $ageLimit
     * @return array
     */
    public function _modelToRow($ageLimit)
    {
        return [
            'id' => $ageLimit->getId(),
            'age' => $ageLimit->getAge(),
        ];
    }
}