<?php
/**
 * This file contains...TODO
 * Created by Soma Veszelovszki <soma.veszelovszki@gmail.com> on 2016-04-26.
 */

namespace Model;

class PersonToSeriesTable extends TableModel {

    const TABLE_NAME = 'person_to_series';

    /**
     * Applies query filters (WHERE, LIMIT, ORDER BY)
     * @param array $filters
     * @param null $order
     * @param null $limit
     */
    protected function _applyFilters(array $filters = [], $order = self::ORDER_NONE, $limit = null) {
        /* Applies filters */
        if (isset($filters['person_id'])) {
            $this->db->where_in('main_table.person_id',
                is_array($filters['person_id']) ? $filters['person_id'] : array((int) $filters['person_id']));
        }

        if (isset($filters['series_id'])) {
            $this->db->where_in('main_table.series_id',
                is_array($filters['series_id']) ? $filters['series_id'] : array((int) $filters['series_id']));
        }

        parent::_applyFilters($filters, $order, $limit);
    }

    protected function _rowToModel($row){
        return new PersonToSeries([
            'id'                =>  (int) $row->id,
            'personId'          =>  (int) $row->person_id,
            'seriesId'          =>  (int) $row->series_id,
            'contributionId'    =>  (int) $row->contribution_id
        ]);
    }

    /**
     * @param PersonToSeries $personToSeries
     * @return array
     */
    protected function _modelToRow($personToSeries)
    {
        return [
            'id'                =>  $personToSeries->getId(),
            'person_id'         =>  $personToSeries->getPersonId(),
            'series_id'         =>  $personToSeries->getSeriesId(),
            'contribution_id'   =>  $personToSeries->getContributionId()
        ];
    }
}