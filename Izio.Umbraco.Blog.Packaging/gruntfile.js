/// <binding AfterBuild='build' ProjectOpened='build' />
module.exports = function (grunt) {

    var name = "Izio.Umbraco.Blog";
    var version = "1.0.0";
    var namespace = "Izio.Umbraco";
    var source = "../Izio.umbraco.Blog/";
    var destination = "../Izio.Umbraco.Blog.Package/";

    grunt.initConfig({
        copy: {
            package: {
                files: [
                    {
                        expand: true,
                        cwd: source + "bin/",
                        src: [
                            "**/" + namespace + ".*.dll"
                        ],
                        dest: destination + "temp/bin/",
                        flatten: true
                    },
                    {
                        expand: true,
                        cwd: source + "App_Plugins",
                        src: ["**"],
                        dest: destination + "temp/App_Plugins/"
                    }
                ]
            }
        },
        umbracoPackage: {
            package: {
                src: destination + "temp/",
                dest: destination,
                options: {
                    name: "Izio.Umbraco.Blog",
                    version: "1.0.0",
                    url: "http://www.izio.co.uk",
                    license: "MIT",
                    licenseUrl: "http://www.izio.co.uk/license/mit",
                    author: "Izio",
                    authorUrl: "http://www.izio.co.uk",
                    readme: "Izio Blog is adds two new content types and associated templates to create collections of articles to your site.",
                    outputName: name + "." + version + ".zip",
                    manifest: "package.xml"
                }
            }
        },
        clean: {
            package: {
                files: {
                    src: ["../Izio.Umbraco.Blog.Package/*", "!../Izio.Umbraco.Blog.Package/*.zip"]
                },
                options: {
                    force: true
                }
            }
        }
    });

    grunt.loadNpmTasks("grunt-contrib-clean");
    grunt.loadNpmTasks("grunt-contrib-copy");
    grunt.loadNpmTasks("grunt-umbraco-package");


    grunt.registerTask("build", ["copy", "umbracoPackage", "clean"]);
    grunt.registerTask("default", ["build"]);
};