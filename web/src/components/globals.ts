import Vue from 'vue';

// https://webpack.js.org/guides/dependency-management/#require-context
const requireComponent = require.context(
  // Look for files in the current directory
  '.',
  // Do not look in subdirectories
  true,
  // Include all ts files
  /[\w-]+\.vue$/,
);

// For each matching file name...
requireComponent.keys().forEach((fileName) => {
  // Get the component config
  const componentConfig = requireComponent(fileName);

  // Get the PascalCase version of the component name
  let componentName = fileName
    // Remove the "./" from the beginning
    .replace(/^\.\//, '')
    // Remove the file extension from the end
    .replace(/\.\w+$/, '');
  const indexOfSlash = componentName.lastIndexOf('/');
  if (indexOfSlash > -1) {
    componentName = componentName.substring(indexOfSlash + 1);
  }

  // Globally register the component
  Vue.component(componentName, componentConfig.default || componentConfig);
});
