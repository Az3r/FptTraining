module.exports = {
  development: {
    client: 'postgresql',
    connection: {
      database: 'personal',
      user: 'root',
      password: 'root',
    },
    pool: {
      min: 2,
      max: 10,
    },
    migrations: {
      directory: 'migrations',
    },
  },

};
