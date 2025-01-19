# Caminho para a pasta onde estão os modelos
$modelsPath = "C:\Users\elisn\Projects\echa-backend-dotnet\Models"

# Caminho para o projeto
$projectPath = "C:\Users\elisn\Projects\echa-backend-dotnet"

# Obter todos os arquivos .cs na pasta Models (ou onde os modelos estão)
$models = Get-ChildItem -Path $modelsPath -Filter "*.cs"

# Para cada modelo encontrado, gerar um controller
foreach ($model in $models) {
    $modelName = [System.IO.Path]::GetFileNameWithoutExtension($model.Name)

    # Executar o comando de scaffolding para gerar o controller
    Write-Host "Gerando controller para: $modelName"

    # Comando para gerar o controller
    dotnet aspnet-codegenerator controller -name "${modelName}Controller" -m $modelName -dc EchaContext -outDir Controllers -api
}