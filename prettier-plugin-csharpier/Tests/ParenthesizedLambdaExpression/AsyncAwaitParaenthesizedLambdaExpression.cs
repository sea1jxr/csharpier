class ClassName
{
    void AsyncAnonymous()
    {
        var task = Task.Factory.StartNew(
            async () =>
            {
                return await new WebClient().DownloadStringTaskAsync(
                    "http://example.com");
            });
    }
}