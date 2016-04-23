<?php
/**
 * This file contains...TODO
 * Created by Soma Veszelovszki <soma.veszelovszki@gmail.com> on 2016-04-23.
 */

namespace Episodeum\Model;

use Episodeum\Model\TableModel;

require('TableModel.php');

class AgeLimitTable extends TableModel {

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
    protected function _modelToRow($ageLimit)
    {
        return [
            'id' => $ageLimit->getId(),
            'age' => $ageLimit->getAge(),
        ];
    }
}