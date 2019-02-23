import Vue from 'vue';

// https://webpack.js.org/guides/dependency-management/#require-context
const requireComponent = require.context(
  // Look for files in the current directory
  '.',
  // Do not look in subdirectories
  false,
  // Include all ts files
  /[\w-]+\.vue$/,
);

// For each matching file name...
requireComponent.keys().forEach((fileName) => {
  if (fileName.indexOf('globals.ts') > -1) {
    return;
  }

  // Get the component config
  const componentConfig = requireComponent(fileName);

  // Get the PascalCase version of the component name
  const componentName = fileName
    // Remove the "./" from the beginning
    .replace(/^\.\//, '')
    // Remove the file extension from the end
    .replace(/\.\w+$/, '');

  console.log(componentName);

  // Globally register the component
  Vue.component(componentName, componentConfig.default || componentConfig);
});
