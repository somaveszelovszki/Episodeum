<?php
/**
 * This file contains...TODO
 * Created by Soma Veszelovszki <soma.veszelovszki@gmail.com> on 2016-04-23.
 */

namespace Model;

class SeriesTable extends TableModel {

    const TABLE_NAME = 'series';

    /**
     * Applies query filters (WHERE, LIMIT, ORDER BY)
     * @param array $filters
     * @param null $order
     * @param null $limit
     */
    protected function _applyFilters(array $filters = [], $order = self::ORDER_NONE, $limit = null) {
        /* Applies filters */
        if (isset($filters['title'])) {
            $this->db->like("main_table.title", $filters['title']);
        }

        parent::_applyFilters($filters, $order, $limit);
    }

    protected function _rowToModel($row){
        return new Series([
            'id'            =>  (int) $row->id,
            'imdbId'        =>  $row->imdb_id ? $row->imdb_id : null,
            'title'         =>  $row->title,
            'ageLimitId'    =>  $row->age_limit_id,
            'genreId'       =>  $row->genre_id,
            'isOnProgram'   =>  $row->is_on_program ? $row->is_on_program : null,
            'showTime'      =>  $row->show_time ? $row->show_time : null,
            'viewNumber'    =>  $row->view_number ? $row->view_number : null,
            'countryId'     =>  $row->country_id
        ]);
    }

    /**
     * @param Series $series
     * @return array
     */
    public function _modelToRow($series)
    {
        return [
            'id'            =>  $series->getId(),
            'imdb_id'       =>  $series->getImdbId(),
            'title'         =>  $series->getTitle(),
            'age_limit_id'  =>  $series->getAgeLimitId(),
            'genre_id'      =>  $series->getGenreId(),
            'is_on_program' =>  $series->getIsOnProgram(),
            'show_time'     =>  getSQLDateTimeFromDateTime($series->getShowTime()),
            'view_number'   =>  $series->getViewNumber(),
            'country_id'    =>  $series->getCountryId()
        ];
    }
}