using System.Net.Http.Json;
using EventEase.Models;

namespace EventEase.service;

public class EventService
{
    private readonly HttpClient _httpClient;
    private static readonly List<Event> _events = new();

    public EventService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Event>> GetEventsAsync()
    {
        if (_events.Count == 0)
        {
            var seed = await _httpClient.GetFromJsonAsync<List<Event>>("sample-data/events.json");
            if (seed != null) _events.AddRange(seed);
        }
        return _events;
    }

    public async Task<Event?> GetEventByIdAsync(Guid id)
    {
        var events = await GetEventsAsync();
        return events.FirstOrDefault(e => e.Id == id);
    }

    public async Task CreateEventAsync(Event newEvent)
    {
        newEvent.Id = Guid.NewGuid();
        _events.Add(newEvent);
        await Task.CompletedTask; // simula async
    }
}