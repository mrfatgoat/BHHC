let gulp = require("gulp");
let browserify = require("browserify");
let tsify = require("tsify");
let source = require("vinyl-source-stream");
let buffer = require("vinyl-buffer");
let sourcemaps = require("gulp-sourcemaps");
let ngify = require("ngify");


gulp.task("default", function (done) {
    console.log("gulp is working!");
    done();
});


gulp.task("compile-ts", function () {
    // Use browserify to compile and bundle all of our front-end assets into a single file
    let bundler = browserify({
        basedir: ".",
        debug: true,
        entries: [
            "ClientApp/app.ts"
        ],
        cache: {},
        packageCache: {}
    })
        // Compiles typescript
        .plugin(tsify)
        // Creates an angular module which caches templates
        .transform(ngify, {
            moduleName: "app.templates",
            htmlPath: "ClientApp/"
        });

    let stream = bundler.bundle()
        .pipe(source("app.js"))
        .pipe(buffer())
        .pipe(sourcemaps.init({ loadMaps: true }))
        .pipe(sourcemaps.write("./"))
        .pipe(gulp.dest("wwwroot/dist"));

    return stream;
});