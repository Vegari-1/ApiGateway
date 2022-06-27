module.exports = {
	branches: ["main", {"name": "develop", "prerelease": true}],
	repositoryUrl: "https://github.com/Vegari-1/ApiGateway",
	plugins: [
		"@semantic-release/commit-analyzer",
		"@semantic-release/release-notes-generator",
		"@semantic-release/github",
		"semantic-release-export-data"
	]
}