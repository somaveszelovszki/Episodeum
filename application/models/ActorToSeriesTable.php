<?php
/**
 * This file contains...TODO
 * Created by Soma Veszelovszki <soma.veszelovszki@gmail.com> on 2016-04-23.
 */

class ActorToSeriesTable extends TableModel {

    protected function _rowToModel($row){
        return new AgeLimit([
            'id'        =>  (int) $row->id,
            'actorId'   =>  (int) $row->actor_id,
            'seriesId'  =>  (int) $row->series_id
        ]);
    }

    /**
     * @param ActorToSeries $actorToSeries
     * @return array
     */
    protected function _modelToRow($actorToSeries)
    {
        return [
            'id'        =>  $actorToSeries->getId(),
            'actor_id'   =>  $actorToSeries->getActorId(),
            'series_id'  =>  $actorToSeries->getSeriesId(),
        ];
    }
}