using FDK;

namespace TJAPlayer3
{
    /// <summary>
    /// 難易度選択画面。
    /// この難易度選択画面はAC7～AC14のような方式であり、WiiまたはAC15移行の方式とは異なる。
    /// </summary>
	internal class CActSelect難易度選択画面 : CActivity
	{
		// プロパティ

		public bool bスクロール中
		{
			get
			{
				if( this.n目標のスクロールカウンタ == 0 )
				{
					return ( this.n現在のスクロールカウンタ != 0 );
				}
				return true;
			}
		}

		// コンストラクタ

        public CActSelect難易度選択画面()
        {
			base.b活性化してない = true;
		}

		public bool bIsDifficltSelect;
		// メソッド


		public void t次に移動()
		{
			if( TJAPlayer3.stage選曲.r現在選択中の曲 != null )
			{
				if (n現在の選択行 < 4)
				{
					this.n現在の選択行++;
				}
				TJAPlayer3.stage選曲.tenkai2 = new CCounter(0, 353, 1, TJAPlayer3.Timer);

			}
		}
		public void t前に移動()
		{
			if (TJAPlayer3.stage選曲.r現在選択中の曲 != null)
			{
				if (n現在の選択行 > -2)
				{
					this.n現在の選択行--;
				}
				TJAPlayer3.stage選曲.tenkai2 = new CCounter(0, 353, 1, TJAPlayer3.Timer);

			}
		}
		public void t選択画面初期化()
		{
			this.b初めての進行描画 = true;
		}

		// CActivity 実装

		public override void On活性化()
		{
			if( this.b活性化してる )
				return;

			this.b登場アニメ全部完了 = false;
			this.n目標のスクロールカウンタ = 0;
			this.n現在のスクロールカウンタ = 0;
			this.nスクロールタイマ = -1;
			this.n現在の選択行 = 0;

			// フォント作成。
			// 曲リスト文字は２倍（面積４倍）でテクスチャに描画してから縮小表示するので、フォントサイズは２倍とする。
			this.ct三角矢印アニメ = new CCounter();
            this.ct移動 = new CCounter();

			base.On活性化();
		}
		public override void On非活性化()
		{
			if( this.b活性化してない )
				return;

			for( int i = 0; i < 13; i++ )
				this.ct登場アニメ用[ i ] = null;

            this.ct移動 = null;
            this.ct三角矢印アニメ = null;

			base.On非活性化();
		}
		public override void OnManagedリソースの作成()
		{
			if( this.b活性化してない )
				return;

            

			base.OnManagedリソースの作成();
		}
		public override void OnManagedリソースの解放()
		{
			if (this.b活性化してない)
				return;

			base.OnManagedリソースの解放();
		}
		public override int On進行描画()
		{
			if( this.b活性化してない )
				return 0;

			#region [ 初めての進行描画 ]
			//-----------------
			if( this.b初めての進行描画 )
			{
				var genreBack = TJAPlayer3.Tx.SongSelect_ND_Genre[CStrジャンルtoNum.ForGenreBackIndex(TJAPlayer3.stage選曲.r現在選択中の曲.strジャンル)];
				if (genreBack != null)
				{
					genreBack.t2D描画(TJAPlayer3.app.Device, 0, 0);
				}

				for (int i = 0; i < 13; i++)
				{
					
				}
				base.b初めての進行描画 = false;
			}
			//-----------------
			#endregion

			// 本ステージは、(1)登場アニメフェーズ → (2)通常フェーズ　と二段階にわけて進む。
			// ２つしかフェーズがないので CStage.eフェーズID を使ってないところがまた本末転倒。

			
			// 進行。
            //this.ct三角矢印アニメ.t進行Loop();

          
			if( !this.b登場アニメ全部完了 )
			{
				#region [ (1) 登場アニメフェーズの進行。]
				//-----------------
				for( int i = 0; i < 13; i++ )	// パネルは全13枚。
				{
					this.ct登場アニメ用[ i ].t進行();

					if( this.ct登場アニメ用[ i ].b終了値に達した )
						this.ct登場アニメ用[ i ].t停止();
				}

				// 全部の進行が終わったら、this.b登場アニメ全部完了 を true にする。

				this.b登場アニメ全部完了 = true;
				for( int i = 0; i < 13; i++ )	// パネルは全13枚。
				{
					if( this.ct登場アニメ用[ i ].b進行中 )
					{
						this.b登場アニメ全部完了 = false;	// まだ進行中のアニメがあるなら false のまま。
						break;
					}
				}
				//-----------------
				#endregion
			}
			else
			{
				#region [ (2) 通常フェーズの進行。]
				//-----------------

				
                //-----------------
                #endregion
            }


            // 描画。



            if (!this.b登場アニメ全部完了)
			{
				#region [ (1) 登場アニメフェーズの描画。]
				//-----------------
				for (int i = 0; i < 4; i++) // パネルは全13枚。
				{
					var genreBack = TJAPlayer3.Tx.SongSelect_ND_Genre[CStrジャンルtoNum.ForGenreBackIndex(TJAPlayer3.stage選曲.r現在選択中の曲.strジャンル)];
					if (genreBack != null)
					{
						genreBack.t2D描画(TJAPlayer3.app.Device, 0, 0);
					}
				}
				//-----------------
				#endregion
			}
			else
			{
                #region [ (2) 通常フェーズの描画。]
                //-----------------
                {

					var genreBack = TJAPlayer3.Tx.SongSelect_ND_Genre[CStrジャンルtoNum.ForGenreBackIndex(TJAPlayer3.stage選曲.r現在選択中の曲.strジャンル)];
					if (genreBack != null)
					{
						genreBack.t2D描画(TJAPlayer3.app.Device, 0, 0);
					}
				}

				
				#endregion
			}

			return 0;
		}


		// その他

		#region [ private ]
		//-----------------

		private CActSelectQuickConfig actQuickConfig;

		private bool b登場アニメ全部完了;
		private CCounter[] ct登場アニメ用 = new CCounter[ 13 ];
        private CCounter ct三角矢印アニメ;
        private CCounter ct移動;
		private long nスクロールタイマ;
		private int n現在のスクロールカウンタ;
		public int n現在の選択行;
		private int n目標のスクロールカウンタ;

       

      

        private CSound soundSelectAnnounce;


        private long n矢印スクロール用タイマ値;

        private int[] n描画順;
      
		//-----------------
		#endregion
	}
}
