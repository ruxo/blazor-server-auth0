using Microsoft.JSInterop;

namespace Blazor.Example;

public sealed class JsInterop
{
    readonly IJSRuntime js;
    public JsInterop(IJSRuntime js) {
        this.js = js;
    }

    public ValueTask PreventBlazorReconnection() => js.InvokeVoidAsync("MyHelpers.preventReconnection");
}