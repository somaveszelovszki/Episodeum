<?php
/**
 * This file contains...TODO
 * Created by Soma Veszelovszki <soma.veszelovszki@gmail.com> on 2016-04-26.
 */

namespace Model;

class ContributionTable extends TableModel {

    const TABLE_NAME = 'contribution';

    protected function _rowToModel($row){
        return new Contribution([
            'id'    =>  (int) $row->id,
            'name'  =>  $row->name
        ]);
    }

    /**
     * @param Contribution $contribution
     * @return array
     */
    protected function _modelToRow($contribution)
    {
        return [
            'id'    => $contribution->getId(),
            'name'  => $contribution->getName(),
        ];
    }
}