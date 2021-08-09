using System.Collections.Generic;

namespace API_Football.SDK.V3
{
    public static class Predictions
    {
        public static ApiResponse<List<Models.ApiPredictionsResponse>> GetPredictions(
            this Instance instance,
            uint fixture)
        {
            return instance.DoCall<List<Models.ApiPredictionsResponse>>($"predictions?fixture={fixture}");
        }
    }
}
