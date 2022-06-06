const { defineConfig } = require('@vue/cli-service')

module.exports = defineConfig({
  transpileDependencies: true,
  outputDir: './wwwroot/dist',
  lintOnSave: false,
  productionSourceMap: true,
  filenameHashing: false,
  runtimeCompiler: true,
})
