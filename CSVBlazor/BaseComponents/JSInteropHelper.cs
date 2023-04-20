using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace CSVBlazor.BaseComponents
{
    public class JSInteropHelper : IAsyncDisposable
    {
        private readonly Lazy<Task<IJSObjectReference>> moduleTask;

        public JSInteropHelper(IJSRuntime jsRuntime)
        {
            moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
               "import", "./_content/CSVBlazor/jsInteropHelper.js").AsTask());
        }

        public async ValueTask<string> Prompt(string message)
        {
            var module = await moduleTask.Value;
            return await module.InvokeAsync<string>("showPrompt", message);
        }

        public async ValueTask EnableNavButton(ElementReference element, bool enable = true)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync("enableNavButton", element, enable);
        }

        public async ValueTask SetInputValue<T>(ElementReference element, T elementValue)
        {
            var module = await moduleTask.Value;
            await module.InvokeVoidAsync("setInputValue", element, elementValue);
        }

        public async ValueTask DisposeAsync()
        {
            if (moduleTask.IsValueCreated)
            {
                var module = await moduleTask.Value;
                await module.DisposeAsync();
            }
        }
    }
}
