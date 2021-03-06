<?php
/**
 * This file contains...TODO
 * Created by Soma Veszelovszki <soma.veszelovszki@gmail.com> on 2016-04-23.
 */

namespace Model;

abstract class TableModel {

    const ORDER_NONE = null;
    const ORDER_BY_ID_ASC = 'id ASC';
    const ORDER_BY_ID_DESC = 'id DESC';
    const TABLE_NAME = null;

    /**
     * @var TableModel The reference to TableModel instance of this class
     */
    private static $_instances = [];

    /**
     * Makes this class usable as a Singleton.
     */
    public static function getInstance() {
        $className = get_called_class();
        if (!isset(self::$_instances[$className])) {
            self::$_instances[$className] = new $className();
        }
        return self::$_instances[$className];
    }

    /**
     * Protected constructor to prevent creating a new instance of the
     * TableModel via the `new` operator from outside of this class.
     */
    protected function __construct()
    {
    }

    /**
     * Private clone method to prevent cloning of the instance of the
     * TableModel instance.
     *
     * @return void
     */
    private function __clone()
    {
    }

    /**
     * Private unserialize method to prevent unserializing of the TableModel
     * instance.
     *
     * @return void
     */
    private function __wakeup()
    {
    }

    /**
     * Allows table models to access CI's loaded classes using the same
     * syntax as controllers.
     *
     * @param  string $key
     * @access private
     */
    public function __get($key) {
        $CI = get_instance();
        return $CI->$key;
    }

    /**
     * Gets the name of the table associated with the descendant class.
     *
     * @return string The table name.
     */
    public function getTableName() {
        return static::TABLE_NAME;
    }

    /**
     * Returns the first result matching the filters. This is a shorthand method to self::getAll(), for simple queries.
     *
     * @param array $filters See the description of self::_applyFilters() for details.
     * @param string $order One of the self::ORDER_* constants to order the results by.
     * @return Model|null The first result, or null if not found.
     */
    public function getOne(array $filters = [], $order = self::ORDER_NONE) {
        $results = $this->getAll($filters, $order, 1);

        return $results ? $results[0] : null;
    }

    /**
     * Returns all objects from the database, optionally filtered.
     * @param array $filters
     * @param null $order
     * @param null $limit
     * @return array
     */
    public function getAll(array $filters = [], $order = self::ORDER_NONE, $limit = null) {
        $this->db->select('main_table.*');
        $this->_applyFilters($filters, $order, $limit);
        $query = $this->db->get(static::TABLE_NAME . ' AS main_table');
        $models = [];
        if ($query) {
            foreach ($query->result() as $row) {
                $models[] = $this->_rowToModel($row);
            }
        }
        /* Returns results */
        return $models;
    }

    /**
     * @param array $filters associative array of filters. Keys are strings, values are the values to filter for.
     *        Filters (keys-value pairs) supported at the moment:
     *             - "id"              => int|array Only deletes rows with the specified id(s).
     * @return boolean True on success, false on failure
     */
    public function delete(array $filters = []) {
        /* Applies filters */
        if (isset($filters['id'])) {
            $this->db->where_in('id', is_array($filters['id']) ? $filters['id'] : array((int) $filters['id']));
        }
        /* Deletes records */
        return $this->db->delete(static::TABLE_NAME);
    }


    /**
     * Applies query filters (WHERE, LIMIT, ORDER BY)
     * @param array $filters
     * @param null $order
     * @param null $limit
     */
    protected function _applyFilters(array $filters = [], $order = self::ORDER_NONE, $limit = null) {
        /* Applies filters */
        if (isset($filters['id'])) {
            $this->db->where_in('main_table.id', is_array($filters['id']) ? $filters['id'] : array((int) $filters['id']));
        }
        /* Applies limit */
        if (isset($limit)) {
            $this->db->limit($limit);
        }
        /* Applies order */
        if ($order) {
            $this->db->order_by($order);
        }
    }

    /**
     * Saves model to DB (UPDATE/INSERT)
     * - updates if model has an id
     * - inserts if model does not have an id
     * @param $model Model
     * @return $this
     * @throws \Exception
     */
    public function save($model) {
        $this->db->trans_start();

        /* Prepares data to be used in a query */
        $modelData = $this->_modelToRow($model);

        $insertNeeded = true;
        $result = false;

        if ($model->getId()) {
            $this->db->where('id', $model->getId());
            $result = $this->db->update(static::TABLE_NAME, $modelData);
        } else {
            $result = $this->db->insert(static::getTableName(), $modelData);
            if ($result) {
                $model->setId($this->db->insert_id());
            }
        }

        if (!$result) {
            $this->db->trans_rollback();
            throw new \Exception(get_class($model) . " could not be saved in the database because of a DB error. Query was:\n"
                . $this->db->last_query() . "\n" . $this->db->_error_message());
        }

        $this->db->trans_complete();
        return $this;
    }
    /**
     * Converts the given model to a format that can be used for insertion to the DB.
     * @param Model $model
     * @return array The raw data to insert to the DB.
     */
    abstract protected function _modelToRow($model);
    /**
     * Converts the given database row to a Model.
     * @param \stdClass $row The raw data from the DB
     * @return Model The new object.
     */
    abstract protected function _rowToModel($row);
}
