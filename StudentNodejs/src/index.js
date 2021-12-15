require('dotenv').config()
const server = require('./server')
const appDebugger = require('debug')('app')

async function start() {
  const app = await server.create()

  const port = process.env.PORT || 3000
  app.listen(port, (err) => {
    if (err) {
      appDebugger(`failed to start with error: ${err}`)
    }
    appDebugger(`successfully started, listening at ${port}`)
  })
}

start()
