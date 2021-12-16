exports.up = function (knex) {
  return knex.schema.createTable('task_events', (table) => {
    table.uuid('id').primary();
    table
      .enum('action', ['create', 'delete', 'move', 'update'], {
        useNative: true,
        enumName: 'task_action',
      })
      .notNullable();
    table
      .integer('move_offset')
      .defaultTo(0)
      .notNullable()
      .comment(
        "when the action is 'move', specify how many rows this item is offset, move up if value is negative, otherwise move down"
      );
    table.boolean('completed').defaultTo(false).notNullable().index();
    table.string('content', 100).index().notNullable();
    table.timestamp('created_at').defaultTo(knex.fn.now()).notNullable();
  });
};

exports.down = function (knex) {
  return knex.schema.dropTable('task_events').raw('drop type task_action');
};
