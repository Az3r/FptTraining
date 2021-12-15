const express = require('express')
const morgan = require('morgan')
const cors = require('cors')
const helmet = require('helmet')

async function create() {
  const server = express()
  server.use(morgan('dev'))
  server.use(cors())
  server.use(express.json())
  server.use(helmet())

  server.get('/', async (_req, res) => {
    res.send('<h1>Hello stranger, I am at your service!</h1>')
  })

  server.use((err, _req, res, next) => {
    if (res.headerSent) return next(err)
    res.status(500)
    res.json({
      message: 'unhandled error has occured',
    })
  })

  return server
}

exports.create = create
