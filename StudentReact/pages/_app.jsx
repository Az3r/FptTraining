import React from 'react'
import { CssBaseline, ThemeProvider } from '@mui/material'
import Head from 'next/head'
import { light } from '../src/styles/theme'

export default function MainApp({ Component, pageProps }) {
  return (
    <>
      <Head>
        <meta name="viewport" content="initial-scale=1, width=device-width" />
      </Head>
      <ThemeProvider theme={light}>
        <CssBaseline />
        <Component {...pageProps} />
      </ThemeProvider>
    </>
  )
}
