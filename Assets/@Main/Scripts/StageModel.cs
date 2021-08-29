using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class StageModel
{
    ReactiveProperty<int> _score;
    public IReadOnlyReactiveProperty<int> scoreProperty
    {
        get { return _score; }
    }

    public StageModel()
    {
        _score = new ReactiveProperty<int>(0);
    }

    public int Score()
    {
        return _score.Value;
    }

    public void ScoreCount(int score)
    {
        _score.Value += score;
    }
}
