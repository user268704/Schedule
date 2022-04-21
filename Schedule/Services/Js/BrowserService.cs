using Microsoft.JSInterop;

namespace Schedule.Services.Js;

public class BrowserService
{
    private IJSRuntime _js;
    public BrowserService(IJSRuntime js)
    {
        _js = js;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns> width, height </returns>
    public async Task<DisplayDimensions> GetDimensions()
    {
        return await _js.InvokeAsync<DisplayDimensions>("getDimensions");
    }

    public class DisplayDimensions
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }
}