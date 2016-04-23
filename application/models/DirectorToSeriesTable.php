<?php
/**
 * This file contains...TODO
 * Created by Soma Veszelovszki <soma.veszelovszki@gmail.com> on 2016-04-23.
 */

class DirectorToSeriesTable extends TableModel {

    protected function _rowToModel($row){
        return new AgeLimit([
            'id'        =>  (int) $row->id,
            'directorId' =>  (int) $row->director_id,
            'seriesId'  =>  (int) $row->series_id
        ]);
    }

    /**
     * @param DirectorToSeries $directorToSeries
     * @return array
     */
    protected function _modelToRow($directorToSeries)
    {
        return [
            'id'            =>  $directorToSeries->getId(),
            'director_id'   =>  $directorToSeries->getDirectorId(),
            'series_id'     =>  $directorToSeries->getSeriesId(),
        ];
    }
}