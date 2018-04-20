# j4net-dotnet-sample
Код для выступления на java.ural.Meetup @1 с докладом "Интеграция виртуальных машин .NET и Java"

## Java sample
Для работы требуется предварительно собрать *j4net-java-sample* (https://github.com/gnkoshelev/j4net-java-sample).

## Build
1. Открыть Solution в **Visual Studio 2015**.
2. Собрать Solution (должен быть настроен NuGet для вытягивания всех зависимостей) в режиме Release (используемый для бенчмарков BenchmarkDotNet не запустится для Debug сборки).

## Run
### HashGrpcBenchmark и HashHttpJsonBenchmark
1. Требуется предварительный запуск соответствующих частей из j4net-java-sample.
2. Запустить *.exe

### HashProxyBenchmark
0. `hash-lib.jar` из *j4net-java-sample* поместить в каталог `binaries`.
1. Создать переменную окружения `JAVA_OPTS=-Djava.class.path=../../../binaries/hash-lib.jar`. Прописывается путь относительный к `HashProxyBenchmark.exe`.
2. Создать переменную окружения `JVM_DLL_PATH=<путь до jvm.dll>`, например `C:\Program Files\Java\jre1.8.0_161\bin\server\jvm.dll`.
3. Создать переменную окружения `JAVA_HOME=<путь до JRE>`, например `C:\Program Files\Java\jre1.8.0_161\`.
4. В переменную окружения `Path` добавить `%JAVA_HOME%\bin;%JAVA_HOME%\bin\server`.
5. Запустить `HashProxyBenchmark.exe`.
