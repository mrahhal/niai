const path = require('path');

module.exports = {
  css: {
    loaderOptions: {
      sass: {
        sassOptions: {
          includePaths: [path.resolve(__dirname, './src/scss')]
        },
        prependData: `
        @import 'variables';
        `,
      }
    }
  }
};
