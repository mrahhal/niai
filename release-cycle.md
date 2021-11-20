# Release Cycle

- Work
- Update the version in "backend/build/version.props" if need be
- When ready, checkout `master` and merge `dev`
- Create an annonated tag on `master`: `git tag -m vx.y.z vx.y.z`
- Push with tags `git push --follow-tags`
- CI will run and if all's well, a deployment will automatically run
- Updating the version for vnext
  - Checkout `dev`
  - Update the version in "backend/build/version.props"
  - `git commit -am "chore: Update version for vnext"`
  - `git push`
