Unity Android CI Pipeline:

This repository contains a Unity project configured with a GitHub Actions CI/CD pipeline that automatically builds Android artifacts (APK and AAB), uploads them as artifacts, and sends Slack notifications after each run.

The workflow is triggered on every push to the `main` branch and can also be executed manually using `workflow_dispatch`.

Pipeline Overview:

When code is pushed to `main`, the following happens:

1. GitHub Actions runner (Ubuntu) starts.
2. Unity Docker image (`unityci/editor:2022.3.59f1-android`) is used.
3. Required secrets are validated.
4. Unity license is activated in batch mode.
5. Android build is executed (APK + AAB).
6. Build output is verified.
7. Artifacts are uploaded.
8. Slack notification is sent (success or failure).
9. Unity license is returned.

Unity version used: 2022.3.59f1

The build runs in batchmode (headless) inside a Docker container to ensure consistent and reproducible builds.
#Build Outputs
The pipeline generates:
- `.apk`
- `.aab`
Both are stored inside:Builds/
They are uploaded using `actions/upload-artifact` and can be downloaded from the GitHub Actions run page.

Required GitHub Secrets:

The following secrets must be configured in:

Unity License & Authentication:
- `UNITY_EMAIL`
- `UNITY_PASSWORD`
- `UNITY_SERIAL`
- 
 Android Signing
- `ANDROID_KEYSTORE` (Base64 encoded)
- `ANDROID_KEYSTORE_PASS`
- `ANDROID_KEY_ALIAS`
- `ANDROID_KEY_ALIAS_PASS`

### Slack Integration
- `SLACK_WEBHOOK_URL`



