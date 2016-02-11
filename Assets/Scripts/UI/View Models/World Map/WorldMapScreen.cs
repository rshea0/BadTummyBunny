﻿using MarkUX;
using Zenject;

namespace PachowStudios.BadTummyBunny.UI
{
  public class WorldMapScreen : View,
    IHandles<LevelSelectedMessage>,
    IHandles<LevelDeselectedMessage>
  {
    [DataBound] public WorldMapLevelPopup LevelPopup = null;

    [Inject] private IEventAggregator EventAggregator { get; set; }

    [PostInject]
    private void PostInject()
      => EventAggregator.Subscribe(this);

    public void Handle(LevelSelectedMessage message)
    {
      this.LevelPopup.Level = message.Level;
      this.LevelPopup.Show();
    }

    public void Handle(LevelDeselectedMessage message)
      => this.LevelPopup.Hide();
  }
}
