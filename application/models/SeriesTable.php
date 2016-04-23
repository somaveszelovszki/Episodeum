<?php
/**
 * This file contains...TODO
 * Created by Soma Veszelovszki <soma.veszelovszki@gmail.com> on 2016-04-23.
 */

class SeriesTable extends TableModel {

    protected function _rowToModel($row){
        return new Series([
            'id'            =>  (int) $row->id,
            'imdbId'        =>  $row->imdb_id ? $row->imdb_id : null,
            'title'         =>  $row->title,
            'ageLimitId'    =>  $row->age_limit_id ? $row->age_limit_id : null,
            'genreId'       =>  $row->genre_id,
            'isOnProgram'   =>  $row->is_on_program ? $row->is_on_program : null,
            'showTime'      =>  $row->show_time ? $row->show_time : null,
            'viewNumber'    =>  $row->view_number ? $row->view_number : null,
            'countryId'     =>  $row->country_id ? $row->country_id : null
        ]);
    }

    /**
     * @param Series $series
     * @return array
     */
    protected function _modelToRow($series)
    {
        return [
            'id'            =>  $series->getId(),
            'imdb_id'       =>  $series->getImdbId(),
            'title'         =>  $series->getTitle(),
            'age_limit_id'  =>  $series->getAgeLimitId(),
            'genre_id'      =>  $series->getGenreId(),
            'is_on_program' =>  $series->getIsOnProgram(),
            'show_time'     =>  $series->getShowTime(),
            'view_number'   =>  $series->getViewNumber(),
            'country_id'    =>  $series->getCountryId()
        ];
    }
}