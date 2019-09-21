# Release Cycle

- Work
- When ready, merge `dev` into `master`
- Release deployment on [appveyor](https://ci.appveyor.com)
- Updating the version
  - Checkout `dev`
  - Update the version in "backend/build/version.props"
  - `$ git commit -am "chore: update version for vnext"`
